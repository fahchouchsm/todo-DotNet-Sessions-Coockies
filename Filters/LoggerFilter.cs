using Microsoft.AspNetCore.Mvc.Filters;
using todoV2.Constant;
using todoV2.data;

namespace todoV2.Filters
{
    public class LoggerFilter : ActionFilterAttribute
    {
        private readonly string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "logs");
        private readonly string filePath;

        public LoggerFilter()
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            filePath = Path.Combine(directoryPath, "actions_logs.txt");

            if(!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }


        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string controllerName = context.Controller.GetType().Name;
            string action = context.ActionDescriptor.DisplayName;
            string status = context.Exception == null ? "success" : context.Exception.Message;
            var logLine = $"[{DateTime.Now}] Controller: {controllerName}, Action: {action}, Status: {status} \n -- ";


            var items = context.HttpContext.Items;
            
            if (items.ContainsKey(LoggerFilterKeys.deleteTodo))
            {
                Todo todo = (Todo) items[LoggerFilterKeys.deleteTodo];
                logLine += "deleting : \n --- " + todo.ToString();
            }

            File.AppendAllText(filePath, logLine + Environment.NewLine);

            base.OnActionExecuted(context);
        }

    }
}
