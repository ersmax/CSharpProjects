Console.Title = "The Password Validator";
while (true)
{
    Console.WriteLine("Enter a new password with the following criteria:" +
                      "\n- length between 6-13" +
                      "\n- at least 1 lowercase character" +
                      "\n- at least 1 uppercase character" +
                      "\n- no & or T");
    Console.Write("> ");
    string password = Console.ReadLine() ?? "password not valid";
    PasswordValidator pwdValidator = new PasswordValidator(password);
    string result = (pwdValidator.IsValid) ? "valid" : "invalid";
    Console.WriteLine($"The password is {result}\n");
}

public class PasswordValidator
{
    private readonly string _password;
    public bool IsValid { get; }

    public PasswordValidator(string password)
    {
        _password = password;
        IsValid = ValidPassword();
    }

    private bool ValidPassword()
    {
        if (_password.Length is < 6 or > 13)
            return false;

        bool hasUppercase = false;
        bool hasLowercase = false;
        bool hasDigit = false;
        bool hasUppercaseT = false;
        bool hasAmpersand = false;
        
        foreach (char letter in _password)
        {
            if (char.IsUpper(letter)) hasUppercase = true;
            if (char.IsLower(letter)) hasLowercase = true;
            if (char.IsDigit(letter)) hasDigit = true;
            if (letter == 'T') hasUppercaseT = true;
            if (letter == '&') hasAmpersand = true;
        }
        return (hasUppercase && hasLowercase && hasDigit && !hasUppercaseT && !hasAmpersand);
    }
}