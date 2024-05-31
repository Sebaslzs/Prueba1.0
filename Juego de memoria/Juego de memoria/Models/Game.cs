using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MemoryGame.Models
{
    public class Game
    {
        public List<Card> Cards { get; set; }
        public int Level { get; set; }

        public Game(int level)
        {
            Level = level;
            Cards = GenerateCards(level).Result;
        }

        private async Task<List<Card>> GenerateCards(int level)
        {
            var cards = new List<Card>();
            var totalPairs = level * 6;
            var imageUrls = await FetchImageUrls(totalPairs);

            for (int i = 0; i < totalPairs; i++)
            {
                var imageUrl = imageUrls[i % imageUrls.Count];
                cards.Add(new Card { Id = i * 2, ImageUrl = imageUrl });
                cards.Add(new Card { Id = i * 2 + 1, ImageUrl = imageUrl });
            }

            return cards.OrderBy(c => System.Guid.NewGuid()).ToList();
        }

        private async Task<List<string>> FetchImageUrls(int count)
        {
            var urls = new List<string>();
            using (var client = new HttpClient())
            {
                for (int i = 0; i < count; i++)
                {
                    var response = await client.GetAsync("https://picsum.photos/200");
                    if (response.IsSuccessStatusCode)
                    {
                        urls.Add(response.RequestMessage.RequestUri.ToString());
                    }
                }
            }
            return urls;
        }
    }
}
