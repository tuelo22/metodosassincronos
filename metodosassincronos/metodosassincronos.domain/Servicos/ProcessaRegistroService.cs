using metodosassincronos.domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodosassincronos.domain.Servicos
{
    public class ProcessaRegistroService(HttpClient _httpClient)
    {
        

        public async Task Processar()
        {
           var response  = _httpClient.GetAsync<DeckResponseDTO>("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1")


        }
    }
}
