using CarnetAdresseXamarin.ViewModels;
using CarnetAdresseXamarin.Services;
using CarnetAdresseXamarin.Models;


namespace TestCarnetAdresse
{
    public class UnitTest1
    {

        [Fact]
        public async Task testAttributs()
        {
            var itemDetailTest = new ItemDetailViewModel();

            string testString = itemDetailTest.Title;

            Assert.Equal(String.Empty, testString);

        }
        [Fact]
        public async Task testisBusy()
        {
            var itemIsBusyTest = new ItemDetailViewModel();

            bool testBool = itemIsBusyTest.IsBusy;

            Assert.True(testBool == false);
        }
    }
}