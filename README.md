# AssetTracking

## Introduction
This console application enables users to input data about various company assets such as laptops and phones and provides functionality to display sorted lists of assets based on different criteria.

## How to Use
1. When prompted, select one of the following options:
   - **A**: Add a new asset.
   - **L**: List all assets.
   - **Q**: Quit the application.
2. Follow the prompts to add a new asset or list all assets.
3. Assets will be displayed sorted by class (computers first, then phones), then by purchase date.
4. Assets nearing their end-of-life will be marked:
   - *Red*: Less than 3 months away from 3 years.
   - *Yellow*: Less than 6 months away from 3 years.

## Features
- **Add Asset**: Users can add a new asset by providing details such as type, brand, model, purchase date, price, and office location.
- **List Assets**: Users can view all assets sorted by class and purchase date, with assets nearing end-of-life marked in *red* and *yellow*.
- **Currency Conversion**: Assets are associated with specific office locations, and prices are converted to the appropriate currency based on today's exchange rates.
- **Error Handling**: The application gracefully handles user input errors and displays error messages when necessary.
- **LINQ Integration**: LINQ is used to sort assets.

## Classes
The application consists of the following classes:
1. **AssetManager**: Manages the list of assets and provides methods for adding assets, listing assets, and displaying error messages.
2. **Asset**: Represents a single asset with properties for brand, model, purchase date, price, and office location.
3. **Phone**: Subclass of Asset, represents a mobile phone asset.
4. **Computer**: Subclass of Asset, represents a computer asset.
5. **Office**: Represents an office location with properties for country and currency.

## How to Run
To run the application, compile and execute the provided C# code using a compatible compiler or integrated development environment (IDE) such as Visual Studio.
