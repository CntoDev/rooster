using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;
using MassTransit;
using Roster.Core.Events;
using Roster.Core.Storage;
using Roster.Infrastructure.Configurations;

namespace Roster.Infrastructure.Consumers
{
    public class EmailSender : IConsumer<MemberCreated>, IConsumer<ApplicationFormRejected>, IConsumer<ApplicationFormSubmitted>
    {
        private readonly EmailService _emailService;
        private readonly IMemberStorage _memberStorage;
        private readonly IEventStore _eventStore;

        public EmailSender(MailJetOptions options, IMemberStorage memberStorage, IEventStore eventStore, EmailService emailVerificationService)
        {
            _memberStorage = memberStorage;
            _emailService = emailVerificationService;
            _eventStore = eventStore;
        }

        public async Task Consume(ConsumeContext<MemberCreated> context)
        {
            var message = context.Message;
            string verificationCode = _emailService.GenerateCode(message.Nickname);

            // save verification code to storage
            var member = _memberStorage.Find(message.Nickname);
            member.ChallengeEmail(verificationCode);
            _memberStorage.Save();

            await _emailService.SendVerificationEmail(message.Email, verificationCode);

            // publish events after checking response
            _eventStore.Publish(member.Events());
        }

        public async Task Consume(ConsumeContext<ApplicationFormRejected> context)
        {
            var message = context.Message;
            await _emailService.SendRejectionEmail(message.Nickname, message.Email, message.Reason);
        }

        public async Task Consume(ConsumeContext<ApplicationFormSubmitted> context)
        {
            var message = context.Message;
            await _emailService.SendApplicationConfirmation(message.Nickname, message.Email);
        }
    }
}