# NDMA - Nutrition and Dietary Manager Assistor

## Final Year Project 2019 - 2020 - Due 11th April at Noon - The correct branch is "MasterPathVersionThree"

### The connetion between the systems

> The activities and layout files that is used for the application to connect to the different functionalities are listed

| Activity        | Layout File       |
| --------------- | ----------------- |
| MainActivity.cs | activity_main.xml |
| Register.cs     | Register.xml      |
| UserLogin.cs    | login.xml         |
| Home.cs         | Home.xml          |

> The activities are assigned into two different activities directory for each main functionlity of the application

| Logging System | Advisor System   |
| -------------- | ---------------- |
| Activities     | AdvisorActivites |

### The logging system

The logging system is one of the two core aspects of the application.
The below table displays the activities and the layout files assoicated with the activity

| Activity                   | First Activity Layout File  | Second Activity Layout File | Third Activity Layout File |
| -------------------------- | --------------------------- | --------------------------- | -------------------------- |
| logDiet.CS                 | FoodDailySchedule.xml       | LogDiet.xml                 | foodloggedlist.Xml         |
| SearchForFoodFromApi.cs    | SearchForFood.xml           | SearchForFoodListView.xml   | NA                         |
| FoodLayoutSpec.cs          | FoodLayoutSpecification.xml | NA                          | NA                         |
| AddAdditionalIngredient.cs | AddAdditionalIngredient.xml | NA                          | NA                         |

The below table displayed the activities, the adpater used with the activity, the layout file the adpater used and whether or not the activity is being used within the system

| Activity                   | Adpater used in Activity        | Adapter layout file                | Activity Being Used |
| -------------------------- | ------------------------------- | ---------------------------------- | ------------------- |
| logDiet.CS                 | CustomDefaultListAdapter.CS     | CustomSimpleListLayout.xml         | Yes                 |
| SearchForFoodFromApi.cs    | CustomSearchedAPIListAdapter.cs | DisplaySearchedAPIListLayout.xml   | Yes                 |
| FoodLayoutSpec.cs          | FoodLayoutSpecArrayAdapter.cs   | FoodLayoutSpecListViewContents.xml | Yes                 |
| AddAdditionalIngredient.cs | ArrayAdapter.cs                 | NA                                 | No                  |

### The Advisor System

The below table displays the activities and the layout files assoicated with the activity

| Actvity                           | First Activity Layout File         | Second Activity Layout File |
| --------------------------------- | ---------------------------------- | --------------------------- |
| AdvisorMain.cs                    | AdvisorMain.xml                    | test_graph_layout.xml       |
| MainAdviseContent.cs              | UserAdviseMainLayout.xml           | NA                          |
| DailyStatusGraph.cs               | GraphLayout.xml                    | NA                          |
| WeeklyStatusGraph.cs              | GraphLayout.xml                    | NA                          |
| OverdoneAdvise.cs                 | UserAdviseMainLayout.xml           | NA                          |
| Underdone.cs                      | UserAdviseMainLayout.xml           | NA                          |
| CheckDailyInputForWeeklySample.cs | CheckDailyInputForWeeklySample.xml | NA                          |
| TestDataSearchAPI.cs              | SearchForFood.xml                  | SearchForFoodListView.xml   |
| TestFoodResults.cs                | TestFoodResults.xml                | TestFoodResultsLayout.xml   |

The below table displayed the activities, the adpater used with the activity, the layout file the adpater used and whether or not the activity is being used within the system

| Activity                          | Adpater used in Activity            | Adapter layout file                | Activity Being Used   |
| --------------------------------- | ----------------------------------- | ---------------------------------- | --------------------- |
| MainAdviseContent.cs              | AdvisorAdapter.cs                   | AdvisorListDisplayFoodContents.xml | Yes but adapter isn't |
| DailyStatusGraph.cs               | NA                                  | NA                                 | No                    |
| WeeklyStatusGraph.cs              | NA                                  | NA                                 | No                    |
| Underdone.cs                      | AdvisorAdapter.cs                   | AdvisorListDisplayFoodContents.xml | No                    |
| CheckDailyInputForWeeklySample.cs | NA                                  | NA                                 | Yes                   |
| TestDataSearchAPI.cs              | TestCustomSearchedAPIListAdapter.cs | DisplaySearchedAPIListLayout.xml   | Yes                   |
| TestFoodResults.cs                | NA                                  | NA                                 | Yes                   |

## Other classes used inside the application itself

### API Resource

RecipeSearchClass.cs - There is not used inside the application itself

### The drawable resource

BackGroundGradient.xml - The background look for the application overall look.
CustomButton.xml - The button look for the application

### JsonLoggedFood directory classes

The directory to read the json string of the food, store them inside different classes and use them within the application for analysis. These classes are:

DBFood,
DBNutrients,
FoodSpec,
Ingredients,
ParsedFoodCollection and
TotalOverallNutrients

### FoodStorageItems

The food items to store and track the movement of the logged food as they get logged themselves. These classes are:

FoodScheduleStorage,
FoodStorageItems and
StaticFoodCollection

## Nutritional Advisor - NutrionalAdvisor.cs

This static class is the main advisor part of the application. It contains the methods which does the analysis of the food provided within the application for the nutrition analysis and return the needed feedback for the user.

The inital plan was to analylise the macronutrients but only got the chance to analysis the calorie intake

## Test Data for the application - these are test data to allow the application to behave as desired rather then use the cloud database

### ZZZTestData Directory - Test data for user information and food information itself

These classes contain the test data for the use of the application. They are known as:

CalculatedSubstance.cs,
Substance.cs,
TestRecAmoDBData.cs and
TestSampleData.cs

### TestStaticData Directory - Test data for Nutrition Advice

The StaticDataModel.cs is used to derive more test data for the usage of the application. For the StaticDataModel.cs, the directory
which it uses it data are contained in the following table

| Directory             | Class used 1             | Class Used 2 |
| --------------------- | ------------------------ | ------------ |
| NutritionalDifficulty | NutritionslDifficulty.cs | NA           |
| FoodAndDiet           | FoodCategory.cs          | Diet.cs      |

# External Applications used and liscenses used for the application

| NDMA Application Functionality | External Application Source Used | Reason                                                            |
| ------------------------------ | -------------------------------- | ----------------------------------------------------------------- |
| Logging System                 | Edamam                           | To access their recipe food database to display to the user       |
| Advisor System                 | Syncfusion                       | To use the chart for display the user trends regarding their food |

With Edamam, an account had to be set up for the use of their database and getting access to the personal limited use through keys and password itself

With Syncfusion, an account had to be made to get access to a 30 day trial liscense (started last Friday 27th March) for the chart usage
