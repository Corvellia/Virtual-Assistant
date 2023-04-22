using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace Virtual_Assistant
{
    public class ChatGPT
    {
        private SpeechSynthesis _speechSynthesis = new SpeechSynthesis();
        public async void invokeChatGpt(string userMessage)
        {
            var service = new OpenAIService(new OpenAiOptions
            {
                ApiKey = "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"
            });

            service.SetDefaultModelId(Models.ChatGpt3_5Turbo);

            var messages = new List<ChatMessage>
            {
                ChatMessage.FromSystem("From now on, you behave like a virtual assistant."),
                ChatMessage.FromUser(userMessage)
            };

            var req = new ChatCompletionCreateRequest
            {
                Messages = messages,
                N = 1,
                MaxTokens = 2000,
                FrequencyPenalty = 2.0f,
                Temperature = 0.1f
            };

            var res = await service.ChatCompletion.CreateCompletion(req);

            if(res.Successful)
            {
                string chatGptReturnMessage = res.Choices.First().Message.Content;
                Console.WriteLine(chatGptReturnMessage);
                _speechSynthesis.SpeakString(chatGptReturnMessage);
            }
        }
    }
}
