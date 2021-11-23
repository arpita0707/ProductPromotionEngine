# ProductPromotionEngine

Code for Promotion Engine using Visual Studio 2022, C#, .NET 6.0, Web API and ClassLibrary

Compile & Build
Ctrl + F5 from visual studio

Swagger page will open by default
Click on first endpoint: GetCartPrice - Try it out

Pass data in below format
[
  {
    "productID": 0,
    "productPrice": 0,
    "quantity": 0
  },
  {
    "productID": 0,
    "productPrice": 0,
    "quantity": 0
  }
]

ProductId will be 1,2,3,4 for A,B,C,D respectively
Price: A=50, B=30, C=20, D=15.
Pass the quantity of products in cart.

Click on execute

Promotions will apply and return the total price
