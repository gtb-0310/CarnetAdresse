using CarnetAdresseXamarin.Services;

namespace TestCarnetAdresse
{
    public class IntegrationTest
    {
        [Fact]
        public async Task testGetItemAsync()
        {
            var mkdtStore = new MockDataStore();
            var testFunc = mkdtStore.GetItemAsync("62a24919ee043e14e4e4309a");
            Assert.NotNull(testFunc);

        }


        [Fact]
        public async Task tesDeleteItemAsync()
        {
            var mkdtStore = new MockDataStore();
            var testFunc = mkdtStore.DeleteItemAsync("62a24919ee043e14e4e4309a");
            Assert.NotNull(testFunc);
        }
    }
}
