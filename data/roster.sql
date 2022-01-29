﻿CREATE TABLE "ApplicationForms" (
    "Nickname" text NOT NULL,
    "DateOfBirth" timestamp with time zone NOT NULL,
    "Email" text NULL,
    "BiNickname" text NULL,
    "SteamId" text NULL,
    "Gmail" text NULL,
    "GithubNickname" text NULL,
    "DiscordId" text NULL,
    "TeamspeakId" text NULL,
    "PreferredPronouns" integer NOT NULL,
    "TimeZone" text NULL,
    "LanguageSkillLevel" integer NOT NULL,
    "PreviousArmaExperience" text NULL,
    "PreviousArmaModExperience" text NULL,
    "DesiredCommunityRole" text NULL,
    "AboutYourself" text NULL,
    "Accepted" boolean NULL,
    "InterviewerComment" text NULL,
    CONSTRAINT "PK_ApplicationForms" PRIMARY KEY ("Nickname")
);


CREATE TABLE "Dlcs" (
    "Name" text NOT NULL,
    CONSTRAINT "PK_Dlcs" PRIMARY KEY ("Name")
);


CREATE TABLE "EventStates" (
    "Id" bigint GENERATED BY DEFAULT AS IDENTITY,
    "EventDate" timestamp with time zone NOT NULL,
    "EventType" text NULL,
    "Json" text NULL,
    CONSTRAINT "PK_EventStates" PRIMARY KEY ("Id")
);


CREATE TABLE "Members" (
    "Nickname" text NOT NULL,
    "DateOfBirth" timestamp with time zone NOT NULL,
    "JoinDate" timestamp with time zone NOT NULL,
    "Email" text NOT NULL,
    "BiNickname" text NULL,
    "SteamId" text NULL,
    "Gmail" text NULL,
    "GithubNickname" text NULL,
    "DiscordId" text NULL,
    "TeamspeakId" text NULL,
    "RankId" integer NULL,
    "Discharged" boolean NOT NULL,
    "EmailVerified" boolean NOT NULL,
    "VerificationCode" text NULL,
    "VerificationTime" timestamp with time zone NULL,
    CONSTRAINT "PK_Members" PRIMARY KEY ("Nickname")
);


CREATE TABLE "Ranks" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    CONSTRAINT "PK_Ranks" PRIMARY KEY ("Id")
);


CREATE TABLE "OwnedDlc" (
    "ApplicationFormNickname" text NOT NULL,
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NULL,
    CONSTRAINT "PK_OwnedDlc" PRIMARY KEY ("ApplicationFormNickname", "Id"),
    CONSTRAINT "FK_OwnedDlc_ApplicationForms_ApplicationFormNickname" FOREIGN KEY ("ApplicationFormNickname") REFERENCES "ApplicationForms" ("Nickname") ON DELETE CASCADE
);


CREATE TABLE "MemberDischarge" (
    "MemberNickname" text NOT NULL,
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "DateOfDischarge" timestamp with time zone NOT NULL,
    "DischargePath" integer NOT NULL,
    "IsAlumni" boolean NOT NULL,
    "Comment" text NULL,
    CONSTRAINT "PK_MemberDischarge" PRIMARY KEY ("MemberNickname", "Id"),
    CONSTRAINT "FK_MemberDischarge_Members_MemberNickname" FOREIGN KEY ("MemberNickname") REFERENCES "Members" ("Nickname") ON DELETE CASCADE
);


CREATE INDEX "IX_Members_Email" ON "Members" ("Email");


