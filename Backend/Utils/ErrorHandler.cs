namespace DHA_Code_Test_Backend
{
	
	public static class ErrorHandler
	{
		public static string GenerateLoggedErrorJson(Exception exc)
		{	

			const string ENVIRONMENT = "local"; 
			
			// TODO: Log err info to file

			string jsonStr = "{";
			jsonStr += "\"err_msg\": \"" + exc.Message + "\", ";
			jsonStr += "\"type\": \"" + exc.GetType() + "\", ";

			// Only print stact trace under local environment
			if (ENVIRONMENT == "local")
			{
				jsonStr+= "\"source\": \"" + exc.Source + "\", ";
				jsonStr += "\"stack_trace\": \"" + exc.StackTrace + "\"";
			}
			jsonStr += "}";
			return jsonStr;
		}
	}
}
