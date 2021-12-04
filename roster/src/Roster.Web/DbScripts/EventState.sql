﻿START TRANSACTION;

CREATE TABLE "EventStates" (
    "Id" bigint GENERATED BY DEFAULT AS IDENTITY,
    "EventDate" timestamp without time zone NOT NULL,
    "Json" text NULL,
    CONSTRAINT "PK_EventStates" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211204083131_EventState', '5.0.9');

COMMIT;

START TRANSACTION;

ALTER TABLE "EventStates" ADD "EventType" text NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211204084856_EventState2', '5.0.9');

COMMIT;

