using metodosassincronos.domain.Servicos;

namespace console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var servicoProcedural = new RealizaProcessamentoPensamentoProceduralService();
            var servicoAssincorno = new RealizaProcessamentoPensamentoAssincronoService();
          
            DateTime inicio = DateTime.Now;

            Console.WriteLine($"{inicio} Iniciando o procedural");
            await servicoProcedural.Processar();

            DateTime fim = DateTime.Now;
            Console.WriteLine($"{fim} finalizando o procedural");

            TimeSpan diferenca = fim - inicio;

            var segundos = diferenca.TotalSeconds;
            Console.WriteLine($"{segundos} Total em segundos");


            inicio = DateTime.Now;

            Console.WriteLine($"{inicio} Iniciando o assincrono");
            await servicoAssincorno.Processar();

            fim = DateTime.Now;
            Console.WriteLine($"{fim} finalizando o assincrono");

            diferenca = fim - inicio;

            segundos = diferenca.TotalSeconds;
            Console.WriteLine($"{segundos} Total em segundos");

            Console.WriteLine($"Finalizado");
        }

   
    }
}