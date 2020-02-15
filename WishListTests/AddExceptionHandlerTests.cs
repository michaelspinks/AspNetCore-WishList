using System.IO;
using Xunit;

namespace WishListTests
{
    public class AddExceptionHandlerTests
    {
        [Fact(DisplayName = "Configure Exception Handling @configure-exception-handling")]
        public void UseDeveloperExceptionPageTest()
        {

            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;

            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (var streamReader = new StreamReader(filePath))
            {
                // Reads all characters from the current position until the end of the stream. 
                file = streamReader.ReadToEnd();
            }

            //Checks that the startup.cs file contains the string
            Assert.True(file.Contains("app.UseDeveloperExceptionPage();"), "`Startup.cs`'s `Configure` did not contain a call to `UseDeveloperExceptionPage`.");
            Assert.True(file.Contains(@"app.UseExceptionHandler(""/Home/Error"")"), "`Startup.cs`'s `Configure` did not contain a call to `UseExceptionHandler` that redirects to the `Home.Error` action.");
        }
    }
}

// https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader.readtoend?view=netframework-4.8
// https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netframework-4.8#examples
