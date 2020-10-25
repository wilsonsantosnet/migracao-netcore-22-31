using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Common.API
{
    public class DateTimePtBrConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
			if (reader.Value.IsNull())
	    		return null;

	   		if (DateTime.TryParse(reader.Value.ToString(), out DateTime data))
	    		return data;

			return null;
		
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString("dd/MM/yyyy HH:mm"));
        }
    }


    public class RawRequestBodyFormatter : InputFormatter
    {
        public RawRequestBodyFormatter()
        {
         
        }


        public override Boolean CanRead(InputFormatterContext context)
        {
        
            return true;
        }


        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;
            var contentType = context.HttpContext.Request.ContentType;

            using (var reader = new StreamReader(request.Body))
            {
                var content = await reader.ReadToEndAsync();
                //var model = JsonSerializer.Deserialize<TypeOf()>(content);
                return await InputFormatterResult.SuccessAsync(content);
            }
            
        }
    }
}
