using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TouristApp_V3.Model;
using TouristApp_V3.View;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace TouristApp_V3
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public static string DBPath = string.Empty;
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Get a reference to the SQLite database
                DBPath = Path.Combine(
                    Windows.Storage.ApplicationData.Current.LocalFolder.Path, "menu.sqlite");
                // Initialize the database if necessary
                using (var db = new SQLite.SQLiteConnection(DBPath))
                {
                    // Create the tables if they don't exist
                    db.CreateTable<Item>();
                    db.CreateTable<Category>();
                    if (db.Table<Category>().Count() < 1)
                    {
                        db.Insert(new Category("Meals") { ID = 1 });
                        db.Insert(new Category("Desserts") { ID = 2 });
                        db.Insert(new Category("Drinks") { ID = 3 });
                    }

                    if (db.Table<Item>().Count() < 1)
                    {
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Pea Soup",
                            Image = "../Assets/Food1.jpg",
                            DES = "Dutch pea soup served with rye bread and if you're not vegan served with smoked bacon",
                            Price = 100
                        });
                        db.Insert(new Item()
                        {

                            CategoryID = 1,
                            Name = "Grilled Salmon",
                            Image = "../Assets/Food2.jpg",
                            DES = "Grilled Salmon with soy sauce and brown sugar marinade with an addition fo Grilled Beans.",
                            Price = 190
                        });
                        db.Insert(new Item()
                        {

                            CategoryID = 1,
                            Name = "Hamburger",
                            Image = "../Assets/Food3.jpg",

                            DES = "with Salad, Cheese, Tomatoes, pickles and a fresh eco beef.",
                            Price = 150
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Hamburger",
                            DES = "with Salad, Cheese, Tomatoes, pickles and a fresh eco beef.",
                            Image = "../Assets/Food3.jpg",
                            Price = 150
                        });

                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Squash Risotto",
                            DES = "If you like the natural sweet flavor of butternut squash, you'll love this risotto! It is so creamy and full of flavor! Great as a side dish or main course.",
                            Image = "../Assets/Food4.jpg",
                            Price = 145
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Pumpkin curry",
                            DES = "A veggie dinner party dish which stands alone as a vegan main course or as a complex side dish perfect served with spiced roast meat or fish",
                            Image = "../Assets/Food5.jpg",
                            Price = 120
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Ribs",
                            DES = "Beef rib, a French style bone-in rib eye steak, served with french fries or potatoes",
                            Image = "../Assets/Food6.jpg",
                            Price = 240
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Ceasars Salad",
                            DES = "salad of romaine lettuce and croutons dressed with parmesan cheese, lemon juice, olive oil, egg, Worcestershire sauce, garlic, and black pepper.",
                            Image = "../Assets/Food7.jpg",
                            Price = 80
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Encebollado",
                            DES = "is a fish stew from Ecuador, regarded as a national dish. It is served with boiled cassava and pickled red onion rings. A dressing of onion is prepared with fresh tomato and spices such as pepper or coriander leaves. It is commonly prepared with albacore, but also tuna, billfish, or bonito. It may be served with ripe avocado.",
                            Image = "../Assets/Food8.jpg",
                            Price = 220
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Dopiaza",
                            DES = "Dopiaza is a South-Asian curry dish. It is prepared with a large amount of onions, both cooked in the curry and as a garnish. In our version there is Beef, red chilli peppers and of course curry.",
                            Image = "../Assets/Food9.jpg",
                            Price = 179
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Frikadeller",
                            DES = "Frikadeller made from pork, chopped onions and bread crumbs served with boiled white potatoes and gravy (brun sovs) accompanied by pickled beetroot",
                            Image = "../Assets/Food10.jpg",
                            Price = 230
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Filet of plaice",
                            DES = "Breaded Filet of Plaice with fried potatoes and remoulade",
                            Image = "../Assets/Food11.jpg",
                            Price = 199
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Aebleflaesk",
                            DES = " fried pork slices served with a compote of apple, onion and bacon served on rugbrod",
                            Image = "../Assets/Food12.jpg",
                            Price = 280
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Medisterpolse",
                            DES = " thick, spicy sausage made of minced pork, fried and served in a variety of ways. We can serve it with rye bread and mustard if asked.",
                            Image = "../Assets/Food13.jpg",
                            Price = 300
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Brandende karlighed",
                            DES = "is a traditional Danish dish[1] of mashed potatoes, butter, and whole milk or cream with Minced meat steaks, capers and carrots",
                            Image = "../Assets/Food14.jpg",
                            Price = 180
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Ollebrod",
                            DES = " It is a kind of porridge made of rugbrod and beer served with whipped cream and a drizzle of orange zest",
                            Image = "../Assets/Food15.jpg",
                            Price = 300
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 1,
                            Name = "Roast Pork",
                            DES = "Served with both boiled and caramelized Potatoes (brunede kartofler)",
                            Image = "../Assets/Food16.jpg",
                            Price = 200
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 2,
                            ID = 3,
                            Name = "Apple charlotte",
                            DES = "Cold Danish charlotte served in a glass with ice cream.",
                            Image = "../Assets/Food17.jpg",
                            Price = 80
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 2,

                            Name = "Rodgrod med flode",
                            DES = "served hot or cold (both are available at every our) as a dessert with milk, a mixture of milk and vanilla sugar, vanilla sauce, (whipped) cream or custard to balance the refreshing taste of the fruit acids.",
                            Image = "../Assets/Food18.jpg",
                            Price = 100
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 2,

                            Name = "Buttermilk koldskal",
                            DES = "Is a sweet cold soup made with buttermilk and eggs, cream, vanilla served with dry, crispy biscuits",
                            Image = "../Assets/Food19.jpg",
                            Price = 50
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 2,

                            Name = "Risalamande",
                            DES = "made out of rice pudding mixed with whipped cream, vanilla, and chopped almonds, can be served cold with a cherry sauce if wanted",
                            Image = "../Assets/Food20.jpg",
                            Price = 80
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 2,

                            Name = "Bábovka",
                            DES = "contains candied fruits and nuts with a layer of sweetened ground poppy seeds. We recommend it with coffee.",
                            Image = "../Assets/Food21.jpg",
                            Price = 100
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 2,

                            Name = "Wuzetka",
                            DES = "sweet cake, consisting of cocoa sponge cake, jam, whipped cream and a chocolate pomade.",
                            Image = "../Assets/Food22.jpg",
                            Price = 120
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 2,

                            Name = "Cheese Cake",
                            DES = " consists of a mixture of soft, fresh cheese, eggs, and sugar. the bottom layer it often consists of a crust or base made from digestive biscuit. Served with all kinds of berries.",
                            Image = "../Assets/Food23.jpg",
                            Price = 90
                        });
                        db.Insert(new Item()
                        {
                            CategoryID = 3,
                            Image = "../Assets/Drink1.jpg",
                            Name = "Orange Juice",
                            DES = "Made from fresh eco Oranges",
                            Price = 20
                        });

                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink2.jpg", Name = "Apple Juice", DES = "Made from fresh eco Apples", Price = 20 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink3.jpg", Name = "Tuborg", DES = "First pilsner that has been brewed in Denmark", Price = 60 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink4.jpg", Name = "Carlsberg", DES = "Most famous Danish Beer. That calls for a Carlsberg!", Price = 60 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink5.jpg", Name = "Pilsner Urquell", DES = "First Pilsner beer in the world", Price = 50 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink6.jpg", Name = "Namyslow", DES = "Namyslow  White wheat is a polish beer from the brewery in Namyslow. YOu can taste wheat when drinking it.", Price = 50 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink7.jpg", Name = "Miloslaw", DES = "Miloslaw unfiltered is a polish Beer from Miloslaw. It's unfiltered (niefiltrowane). WOn the Grand Prix Chmielaki in 2012", Price = 50 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink8.jpg", Name = "Dark Rain", DES = "Black Pale Ale from Oregon's oldest craft brewery BridgePort Brewing", Price = 100 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink9.jpg", Name = "Sobieski", DES = "One of the best Polish Vodka. Great with fish.", Price = 20 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink10.jpg", Name = "Barrail Meyney", DES = "Great red wine from 2009 from Bordeaux", Price = 60 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink11.jpg", Name = "Casa Mia Fiano", DES = "Wine from the vineyards of France, this wine brand has a hint of honey which gives it a heavenly taste and aroma.", Price = 50 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink12.jpeg", Name = "Coca Cola", DES = "The most popular Soft Drink in the world", Price = 50 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink13.jpg", Name = "Coffee", DES = "The best dark drink ever invented by man kind.", Price = 30 });
                        db.Insert(new Item() { CategoryID = 3, Image = "../Assets/Drink14.jpg", Name = "Tea", DES = "Is it 5PM already?", Price = 30 });
                    }
                }
                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(TableSettings), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
