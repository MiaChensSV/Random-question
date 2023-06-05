namespace DHA_Code_Test_Backend.Models
{
	public class QuestionModel
	{
		public int QuestionAnswerId{ get; set; }
		public string QuestionText { get; set; } = null!;
		public OptionModel[] Options { get; set; } = null!;
		public QuestionModel(int questionAnswerId, string questionText, OptionModel[] options) 
		{
			this.QuestionText = questionText;
			this.QuestionAnswerId= questionAnswerId;
			this.Options = options;
		}
	}
}
