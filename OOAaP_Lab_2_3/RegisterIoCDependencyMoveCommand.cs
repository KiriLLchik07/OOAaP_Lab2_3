using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSpace
{
    public class RegisterIoCDependencyMoveCommand : ICommand
    {
        private readonly IServiceCollection _services;

        public RegisterIoCDependencyMoveCommand(IServiceCollection services)
        {
            _services = services;
        }

        public void Execute()
        {
            // Регистрация зависимости MoveCommand
            _services.AddTransient<IMoving, MoveCommand>(provider =>
            {
                var obj = provider.GetService<object>(); // Здесь предполагается, что объект будет получен из контекста
                var rotatingObject = IoC.Resolve("Adapters.IMoving", obj); // Используйте ваш адаптер для преобразования объекта в IMoving
                return new MoveCommand(rotatingObject);
            });
        }
    }

}
