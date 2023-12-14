string folderPath = @"C:\Users\Makrus\Desktop\Data";
string fileName = "shoppinglist.txt";
string filePath = Path.Combine(folderPath, fileName);

List<string> myshoppingList = new List<string>();

if (File.Exists(filePath))
{
    myshoppingList = GetItemsFromUser();       
    File.WriteAllLines(filePath, myshoppingList);
    ShowItemsFromList(myshoppingList); //Lisasin selle kuna tahtsin et näitaks mida ma lisasin listi, videos ei olnud seda aga muidud oleks kasutamatta kood all :)
}
else
{
    File.Create(filePath).Close();
    Console.WriteLine($"File {fileName} has been created.");
    myshoppingList =GetItemsFromUser();
    File.WriteAllLines(filePath, myshoppingList);
}



//Peamine kodi osa mis laseb teha listi ja sinna lisada asju
static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>();

    while (true)
    {
        Console.WriteLine("Add and item (add) / Exit (exit):");
        string userChoise = Console.ReadLine();

        if (userChoise == "add")
        {
            Console.WriteLine("Enter an item:");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else
        {
            Console.WriteLine("Bye!");
            break;
        }
    }

 
    return userList;
}

//Koodi osa lihtsalt näitab mis on varasemasse listi pandud asju nummertatult
static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();

    int listLength = someList.Count;
    Console.WriteLine($"You have added {listLength} items to your shopping list.");

    int i = 1;
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }

}