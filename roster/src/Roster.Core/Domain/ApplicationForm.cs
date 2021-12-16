using System;
using System.Collections.Generic;
using Roster.Core.Events;

namespace Roster.Core.Domain
{
    public class ApplicationForm : AggregateRoot
    {
        public MemberNickname Nickname { get; }
        public DateTime DateOfBirth { get; }
        public EmailAddress Email { get; }
        public string BiNickname { get; set; }
        public string SteamId { get; set; }
        public EmailAddress Gmail { get; set; }
        public string GithubNickname { get; set; }
        public DiscordId DiscordId { get; set; }
        public string TeamspeakId { get; set; }
        public ICollection<OwnedDlc> OwnedDlcs { get; set; }
        public bool? Accepted { get; private set; }
        public string InterviewerComment { get; private set; }
        public bool Processed => Accepted.HasValue;

        internal ApplicationForm(MemberNickname nickname, DateTime dateOfBirth, EmailAddress email)
        {
            Nickname = nickname;
            DateOfBirth = dateOfBirth;
            Email = email;
        }

        private ApplicationForm() { }

        internal void Accept()
        {
            if (Processed)
                return;

            Accepted = true;
            Publish(ApplicationFormAccepted.CreateFromApplicationForm(this));
        }

        internal void Reject(string comment)
        {
            if (Processed)
                return;
            
            Accepted = false;
            InterviewerComment = comment;
            Publish(new ApplicationFormRejected(Nickname.ToString(), Email.ToString(), comment));
        }
    }
}