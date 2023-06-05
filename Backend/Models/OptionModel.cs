namespace DHA_Code_Test_Backend.Models;

public enum Option: int { One = 0, X = 1, Two = 2 }	
public class OptionModel
{
	public Option OptionValue { get; set; }
	public string OptionText { get; set; }
	public OptionModel(Option optionValue, string optionText)
	{
		this.OptionValue = optionValue;
		this.OptionText = optionText;
	}
}
