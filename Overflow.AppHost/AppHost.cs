var builder = DistributedApplication.CreateBuilder(args);

var keycloak = builder.AddKeycloak("keycloak", 6001)
    .WithDataVolume("keycloak-data");

var questionService = builder.AddProject<Projects.QuestionService>("question-svc", launchProfileName: "https")
    .WithReference(keycloak)
    .WaitFor(keycloak);

builder.Build().Run();
