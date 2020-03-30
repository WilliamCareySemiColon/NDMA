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
