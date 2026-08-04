using InterviewPrepApp.DTOs.AI;
using OpenAI;
using OpenAI.Chat;

namespace InterviewPrepApp.Services
{
    public class AIService : IAIService
    {
        private readonly IConfiguration _configuration;

        public AIService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AIResponseDTO> AskAsync(AIRequestDTO request)
        {
            var endpoint = new Uri(_configuration["AzureOpenAI:Endpoint"]!);

            var apiKey = _configuration["AzureOpenAI:ApiKey"]!;

            var deployment = _configuration["AzureOpenAI:DeploymentName"]!;

            var options = new OpenAIClientOptions
            {
                Endpoint = endpoint
            };

            var client = new OpenAIClient(
                new System.ClientModel.ApiKeyCredential(apiKey),
                options);

            ChatClient chatClient = client.GetChatClient(deployment);

            ChatCompletion completion = await chatClient.CompleteChatAsync(
            [
                new UserChatMessage(request.Prompt)
            ]);

            return new AIResponseDTO
            {
                Response = completion.Content[0].Text
            };
        }
    }
}