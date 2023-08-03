using System.Reflection;

class AttributesSample
{
    public void MyMethod(int int1m, out string str2m, ref string str3m)
    {
        if (str3m is null)
        {
            throw new ArgumentNullException(nameof(str3m));
        }

        str2m = "in MyMethod";
    }

    public static string GetName(AttributesSample attrSample)
    {
        return "";  
    }


    public static int Main(string[] args)
    {
        Console.WriteLine("Reflection.MethodBase.Attributes Sample");

        var attSample = new AttributesSample();
        string name = AttributesSample.GetName(attSample);

        // Get the type.
        Type? MyType = Type.GetType("AttributesSample");

        // Get the method Mymethod on the type.
        MethodBase? myMethodBase = MyType?.GetMethod("MyMethod");

        // Display the method name.
        Console.WriteLine("MyMethodBase = " + myMethodBase);

        // Get the MethodAttribute enumerated value.
        MethodAttributes Myattributes = myMethodBase.Attributes;

        // Display the flags that are set.
        PrintAttributes(typeof(MethodAttributes), (int)Myattributes);
        return 0;
    }

    public static void PrintAttributes(Type attribType, int iAttribValue)
    {
        if (!attribType.IsEnum)
        {
            Console.WriteLine("This type is not an enum.");
            return;
        }

        var fields = attribType.GetFields(BindingFlags.Public | BindingFlags.Static);
        foreach (FieldInfo field in fields)
        {
            int fieldValue = (int)field.GetValue(null);
                
            if ((fieldValue & iAttribValue) == fieldValue)
            {
                Console.WriteLine(field.Name);
            }
        }
    }
}