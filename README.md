
# Simple Warehouse
Simple Warehouse application that keeps track of sold products, can make revision and it can simulate product delivery and product sale

**NOTE!!**
This repo is **very** old and this is my first attempt at building desktop applications with WinForms so I have messed up the code big time. 
Oddly enough this app is used by few businesses so I still make some updates to the code from time to time in order to fix some bugs.
I am looking to build a new warehouse application in the future on much better technology with much more functionality.

# Notable mentions
* App is not tied to one database. Instead it lets the user create and connect to it's own databases. This was done in order to improve performance. If the user has multiple warehouses, he can have separate DB for each warehouse. Thus, reducing product and transaction clutter in each DB.
* Custom event system - I made this app non async, which is not something to be proud of 😁, but I did implement event system that is also synchronous.
* Using State pattern for handling pages - As I mentioned, I wasn't very familiar  with WinForms so I decided to borrow the State pattern, which I usually use in games. It did turn out OK in the end.
* Using **Custom ORM** - this is no longer the case, but if you go back to older commits, you can actually see that I had my own very basic commit. Now I am using **EntityFramework**.
