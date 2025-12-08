using todoV2.data;
using todoV2.ViewModels;

namespace todoV2.Mappers
{
    public class TodoMapper
    {
        public static Todo getTodoFromTodoAddVM(TodoAddVm vm)
        {
            return new Todo
            {
                Libelle = vm.Libelle,
                Description = vm.Description,
                DateLimit = vm.DateLimit,
                State = vm.State
            };
        }
    }
}
