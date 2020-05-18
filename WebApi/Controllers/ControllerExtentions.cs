using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace WebApi.Controllers
{
    public static class ControllerExtentions
    {
        public static string[] SplitField(string fields)
        {
            List<string> arrayStr = new List<string>();
            int depthInside = 0;
            string currentStr = "";
            for(int i = 0; i < fields.Length; i++)
            {
                switch (fields[i])
                {
                    case ',':
                        if (depthInside == 0)
                        {
                            arrayStr.Add(currentStr);
                            currentStr = "";
                            continue;
                        }
                        break;
                    case '[': depthInside++; break;
                    case ']': depthInside--; break;
                }
                currentStr += fields[i];
            }
            arrayStr.Add(currentStr);
            return arrayStr.ToArray();
        }

        public static string MakeDefaultFields(object item)
        {
            string fields = "";
            foreach (PropertyInfo prop in item.GetType().GetProperties())
                fields += prop.Name+",";
            return fields;
        }

        public static object MapListToJsonObject(this Controller controller, object items, string fields)
        {
            List<object> newList = new List<object>();
            foreach (object item in items as List<object>)
                newList.Add(controller.MapToJsonObject(item,fields));
            return newList;
        }

        public static object MapToJsonObject(this Controller controller, object item, string fields)
        {
            if (fields == null) fields = MakeDefaultFields(item);

            var obj = new ExpandoObject() as IDictionary<string, object>;
            PropertyInfo prop = null;

            string[] attriubtes; 
            if (fields.IndexOf(',') == -1 && fields.IndexOf('[') == 1)
                attriubtes = new string[] { fields };
            else attriubtes = SplitField(fields);

            foreach (string attriubte in attriubtes)
            {
                string field = attriubte;
                string insideField = null;
                int leftBracketIndex = field.IndexOf('[');
                if(leftBracketIndex != -1)
                {
                    insideField = field.Substring(leftBracketIndex+1, (field.Length-1) - (leftBracketIndex+1));
                    field = field.Substring(0, leftBracketIndex);
                }
                
                prop = item.GetType().GetProperty(field);
                if (prop != null)
                {
                    object value = prop.GetValue(item);
                    if (value == null) continue;
                    
                    if (value is IEnumerable && !(value is string))
                    {
                        List<object> newList = new List<object>();
                        IEnumerable list = value as IEnumerable;
                        foreach (object o in list) newList.Add(controller.MapToJsonObject(o, insideField));
                        obj.Add(field, newList);
                        continue;
                    }

                    obj.Add(field, value);
                }
            }
            return obj;
        }

        public static OkObjectResult Return(this Controller controller, Func<object> action)
        {
            try
            {
                object result = action();
                if(result == null)  return controller.Ok(new { CommandResult = "Succeed" });
                else return controller.Ok(result);
            }
            catch (Exception e)
            {
                return controller.Ok(new { CommandResult = "Failed", ErrorType = e.GetType().Name, ErrorMessage = e.Message });
            } 
        }
    }
}
