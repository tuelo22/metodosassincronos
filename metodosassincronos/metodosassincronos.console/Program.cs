using metodosassincronos.domain.Servicos;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddHttpClient() 
                .BuildServiceProvider();

            var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

            JsonplaceholderService service = new(httpClientFactory);

            var usuario = await service.GetUsuario("Bret", "Sincere@april.biz");

            if(usuario != null)
            {
                Console.WriteLine($"Enviando requisição");

                var postsprocessamento = service.GetPostUsuario(usuario.Value.Id);
                var albumsprocessamento = service.GetAlbumsUsuario(usuario.Value.Id);

                EscreveTexto();

                Console.WriteLine($"Aguardando API");

                var posts = await postsprocessamento;
                var albums = await albumsprocessamento;

                var post = posts == null ? 0 : posts.Count;
                var album = albums == null ? 0 : albums.Count;

                Console.WriteLine($"O usuario tem {post} posts e {album} albuns.");
            }

            Console.WriteLine($"Finalizado");
        }

        private static void EscreveTexto()
        {
            var texto0 = @"
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam porta, neque sed vehicula pharetra, mauris arcu volutpat enim, ut vehicula nulla nisi in ipsum. Proin ligula enim, vestibulum a dapibus id, faucibus vitae nulla. Mauris quis euismod purus, sed fermentum nunc. Suspendisse a libero sed enim auctor maximus sed fringilla elit. In ullamcorper feugiat ante eget rutrum. Aenean tristique tristique erat ac maximus. Duis venenatis mi in ligula bibendum, ac volutpat neque posuere. Praesent in posuere libero. Nunc eleifend urna non ante placerat, ac rutrum justo lacinia. Cras in purus ut odio commodo interdum. Proin posuere tincidunt ultricies. Phasellus aliquet massa malesuada enim scelerisque facilisis. Quisque eleifend, augue quis fringilla volutpat, turpis risus pharetra sapien, sed dignissim mauris augue sit amet dui. Aliquam arcu sem, auctor eu elit rhoncus, aliquet iaculis diam. Fusce non turpis bibendum, ultricies arcu at, eleifend arcu.

                Donec sed aliquet nunc. Ut a sem eu tellus convallis vulputate. Morbi nec iaculis sem, non hendrerit orci. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis in quam eget efficitur. Praesent eget vulputate leo. Donec sollicitudin porta sapien, varius viverra urna suscipit nec. Donec egestas massa sit amet leo dignissim pretium. Maecenas finibus ac lacus a tempus. Morbi faucibus urna quis ullamcorper sodales. Praesent faucibus sapien eu dui vestibulum, at accumsan ligula vehicula. Nam ultricies orci in molestie porttitor.

                Maecenas in neque nibh. Fusce egestas viverra elit et tempus. Sed sagittis massa eget vehicula euismod. Cras ullamcorper pretium ipsum id vehicula. Donec ac suscipit nisl, rhoncus tempor lorem. Etiam dapibus neque luctus, eleifend lectus id, venenatis libero. Vestibulum libero mi, semper bibendum imperdiet bibendum, fringilla vel dolor. Ut tempor fermentum ex, a maximus lacus. Morbi venenatis tortor id risus sagittis, eu tincidunt orci aliquam. Sed rhoncus nunc at lobortis euismod. In non enim vitae nisi euismod bibendum ut mattis turpis. Etiam ut dignissim felis, id sollicitudin nisl. Vivamus luctus ex a malesuada bibendum.
            ";

            var texto1 = @"
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam porta, neque sed vehicula pharetra, mauris arcu volutpat enim, ut vehicula nulla nisi in ipsum. Proin ligula enim, vestibulum a dapibus id, faucibus vitae nulla. Mauris quis euismod purus, sed fermentum nunc. Suspendisse a libero sed enim auctor maximus sed fringilla elit. In ullamcorper feugiat ante eget rutrum. Aenean tristique tristique erat ac maximus. Duis venenatis mi in ligula bibendum, ac volutpat neque posuere. Praesent in posuere libero. Nunc eleifend urna non ante placerat, ac rutrum justo lacinia. Cras in purus ut odio commodo interdum. Proin posuere tincidunt ultricies. Phasellus aliquet massa malesuada enim scelerisque facilisis. Quisque eleifend, augue quis fringilla volutpat, turpis risus pharetra sapien, sed dignissim mauris augue sit amet dui. Aliquam arcu sem, auctor eu elit rhoncus, aliquet iaculis diam. Fusce non turpis bibendum, ultricies arcu at, eleifend arcu.

                Donec sed aliquet nunc. Ut a sem eu tellus convallis vulputate. Morbi nec iaculis sem, non hendrerit orci. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis in quam eget efficitur. Praesent eget vulputate leo. Donec sollicitudin porta sapien, varius viverra urna suscipit nec. Donec egestas massa sit amet leo dignissim pretium. Maecenas finibus ac lacus a tempus. Morbi faucibus urna quis ullamcorper sodales. Praesent faucibus sapien eu dui vestibulum, at accumsan ligula vehicula. Nam ultricies orci in molestie porttitor.

                Maecenas in neque nibh. Fusce egestas viverra elit et tempus. Sed sagittis massa eget vehicula euismod. Cras ullamcorper pretium ipsum id vehicula. Donec ac suscipit nisl, rhoncus tempor lorem. Etiam dapibus neque luctus, eleifend lectus id, venenatis libero. Vestibulum libero mi, semper bibendum imperdiet bibendum, fringilla vel dolor. Ut tempor fermentum ex, a maximus lacus. Morbi venenatis tortor id risus sagittis, eu tincidunt orci aliquam. Sed rhoncus nunc at lobortis euismod. In non enim vitae nisi euismod bibendum ut mattis turpis. Etiam ut dignissim felis, id sollicitudin nisl. Vivamus luctus ex a malesuada bibendum.
            ";

            var texto2 = @"
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam porta, neque sed vehicula pharetra, mauris arcu volutpat enim, ut vehicula nulla nisi in ipsum. Proin ligula enim, vestibulum a dapibus id, faucibus vitae nulla. Mauris quis euismod purus, sed fermentum nunc. Suspendisse a libero sed enim auctor maximus sed fringilla elit. In ullamcorper feugiat ante eget rutrum. Aenean tristique tristique erat ac maximus. Duis venenatis mi in ligula bibendum, ac volutpat neque posuere. Praesent in posuere libero. Nunc eleifend urna non ante placerat, ac rutrum justo lacinia. Cras in purus ut odio commodo interdum. Proin posuere tincidunt ultricies. Phasellus aliquet massa malesuada enim scelerisque facilisis. Quisque eleifend, augue quis fringilla volutpat, turpis risus pharetra sapien, sed dignissim mauris augue sit amet dui. Aliquam arcu sem, auctor eu elit rhoncus, aliquet iaculis diam. Fusce non turpis bibendum, ultricies arcu at, eleifend arcu.

                Donec sed aliquet nunc. Ut a sem eu tellus convallis vulputate. Morbi nec iaculis sem, non hendrerit orci. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis in quam eget efficitur. Praesent eget vulputate leo. Donec sollicitudin porta sapien, varius viverra urna suscipit nec. Donec egestas massa sit amet leo dignissim pretium. Maecenas finibus ac lacus a tempus. Morbi faucibus urna quis ullamcorper sodales. Praesent faucibus sapien eu dui vestibulum, at accumsan ligula vehicula. Nam ultricies orci in molestie porttitor.

                Maecenas in neque nibh. Fusce egestas viverra elit et tempus. Sed sagittis massa eget vehicula euismod. Cras ullamcorper pretium ipsum id vehicula. Donec ac suscipit nisl, rhoncus tempor lorem. Etiam dapibus neque luctus, eleifend lectus id, venenatis libero. Vestibulum libero mi, semper bibendum imperdiet bibendum, fringilla vel dolor. Ut tempor fermentum ex, a maximus lacus. Morbi venenatis tortor id risus sagittis, eu tincidunt orci aliquam. Sed rhoncus nunc at lobortis euismod. In non enim vitae nisi euismod bibendum ut mattis turpis. Etiam ut dignissim felis, id sollicitudin nisl. Vivamus luctus ex a malesuada bibendum.
            ";

            Console.WriteLine(texto0);
            Console.WriteLine(texto1);
            Console.WriteLine(texto2);
        }
    }
}