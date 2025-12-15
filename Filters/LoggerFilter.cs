using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using todoV2.Constant;
using todoV2.data;
using System.Collections.Generic;

namespace todoV2.Filters
{
    public class LoggerFilter : ActionFilterAttribute
    {
        private readonly string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "logs");
        private readonly string filePath;

        public LoggerFilter()
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            filePath = Path.Combine(directoryPath, "actions_logs.log");

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string controllerName = context.Controller.GetType().Name;
            string actionName = context.ActionDescriptor.DisplayName!;
            string status = context.Exception == null ? "Success" : context.Exception.Message;

            var logBuilder = new StringBuilder();
            logBuilder.AppendLine($"[{DateTime.Now}] Controller: {controllerName}, Action: {actionName}, Status: {status}");

            var items = context.HttpContext.Items;
            LogTodoAction(items, LoggerFilterKeys.deleteTodo, "Deleting", logBuilder);
            LogTodoAction(items, LoggerFilterKeys.addTodo, "Adding", logBuilder);
            LogTodoAction(items, LoggerFilterKeys.editTodo, "Editing", logBuilder);

            File.AppendAllText(filePath, logBuilder.ToString() + Environment.NewLine);

            base.OnActionExecuted(context);
        }

        private void LogTodoAction(IDictionary<object, object?> items, string key, string actionLabel, StringBuilder logBuilder)
        {
            if (items.ContainsKey(key) && items[key] is Todo todo)
            {
                logBuilder.AppendLine($"{actionLabel}:\n--- {todo}");
            }
        }
    }
}
