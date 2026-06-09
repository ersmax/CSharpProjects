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
    public bool IsValid { get; }

    public PasswordValidator(string password)
    {
        IsValid = ValidPassword(password);
    }

    private bool ValidPassword(string password)
    {
        if (password.Length is < 6 or > 13) return false;

        bool hasUppercase = false;
        bool hasLowercase = false;
        bool hasDigit = false;
        foreach (char letter in password)
        {
            // use short-circuit when possible
            if (letter == 'T') return false;
            if (letter == '&') return false;
            if (!hasUppercase && char.IsUpper(letter)) hasUppercase = true;
            if (!hasLowercase && char.IsLower(letter)) hasLowercase = true;
            if (!hasDigit && char.IsDigit(letter)) hasDigit = true;
        }
        return (hasUppercase && hasLowercase && hasDigit);
    }
}