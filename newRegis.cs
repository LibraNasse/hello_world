/*
 * C# Program to Implement a PhoneBook by a console application.
 * The phoneBook is a text file where each line of it includes a
 * person name and his/her phone number of the form person:phoneNumber.
 */
using System;
using System.Collections;
using System.IO;
class PhoneBook
{
	static void Main(string[] arg)
	{
		string fileName;
		int choice;
		bool check = true;
        if (arg.Length > 0)
		{
			fileName = arg[0];
		}
		else
        { 
            fileName = "phoneB.txt";
        }
		while (check)
		{
			Console.Write("\nSelect your option : \n");
			Console.Write("1. Read from phonebook\n");
			Console.Write("2. Add to phonebook\n");
			Console.Write("3. Delete from phonebook\n");
		        Console.Write("4. Exit\n");
			try
			{
				choice = int.Parse(Console.ReadLine());
				switch (choice)
				{
					case 1:
						readInfo(fileName);
						break;
					case 2:
						addInfo(fileName);
						break;
					case 3:
					    deleteInfo(fileName);
						break;
					case 4:
						check = false;
						break;
					default:
						Console.WriteLine("\n Please choose one of the options");
						break;
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
	static void readInfo(string filename)
	{
		Hashtable hashtable = new Hashtable();
		StreamReader r = File.OpenText(filename);
                string line = r.ReadLine();  
		while (line != null)
		{
			int pos = line.IndexOf(":");
			if (pos >=0)
			{
				string name = line.Substring(0, pos).Trim();  
                long phone = Convert.ToInt64(line.Substring(pos + 1));
                hashtable[name] = phone;
			}
			line = r.ReadLine();
		}
		r.Close();
		Console.Write("Enter the name of the person: ");
		string newName = Console.ReadLine().Trim();
		object newPhone = hashtable[newName];
		if (newPhone == null)
		{
			Console.WriteLine("-- Not Found in Phone Book");
		}
		else
		{
			Console.WriteLine(newName+" phone number is "+newPhone+".");
		}
	}
	static void addInfo(string filename)
	{
		Hashtable hashtable = new Hashtable();
		StreamReader r = File.OpenText(filename);
                string line = r.ReadLine();  
		while (line != null)
		{
			int pos = line.IndexOf(":");
			if (pos >=0)
			{
				string name = line.Substring(0, pos).Trim(); 
                long phone = Convert.ToInt64(line.Substring(pos + 1));
                hashtable[name] = phone;
			}
			line = r.ReadLine();
		}
		r.Close();
		using (TextWriter w = File.AppendText(filename))
		{
			Console.WriteLine("Enter the name of the new person: ");
                        string personName = Console.ReadLine().Trim();
			while(!IsAllLetters(personName)||String.IsNullOrEmpty(personName))
			{
				Console.WriteLine("The Name should include at least one letter.");
				Console.WriteLine("The Name can include only letters and white spaces.");
				Console.WriteLine("Please enter the name again:");
                                personName = Console.ReadLine().Trim();
			}
			if (hashtable.ContainsKey(personName))
			{
				Console.WriteLine("Person already exists in the phonebook.");
			}
			else
			{
				Console.WriteLine("Enter the phone number of the person without white space:");
			        int personNumber = int.Parse(Console.ReadLine());
			        w.WriteLine(personName+":"+personNumber);
				Console.WriteLine("\n"+personName+" was added to the phonebook.");
			}
		}
	}
	static void deleteInfo(string filename)
	{
		StreamReader r = File.OpenText(filename);
		Console.WriteLine("Enter the name of the person: ");
		string deleteName = Console.ReadLine().Trim();
		string line;
		string n = "";
		while ((line = r.ReadLine()) != null)
		{
			int pos = line.IndexOf(":");
			if (pos >=0)
			{
				string name = line.Substring(0, pos).Trim();
				if (name != deleteName)
				{
					n += line+Environment.NewLine;
				}
			}
		}
		r.Close();
	        File.WriteAllText(filename, n);
		Console.WriteLine("\n"+deleteName+" was deleted from phonebook.");
	}
	public static bool IsAllLetters(string s)
	{
		foreach (char c in s)
		{
			if (!(Char.IsLetter(c)||Char.IsWhiteSpace(c)))
			{
				return false;
			}
		}
		return true;
	}
}
