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

> The activities are assigned into two different activities directory

| Logging System | Advisor System   |
| -------------- | ---------------- |
| Activities     | AdvisorActivites |

### The logging system

The logging system is one of the two core aspects of the application.

| Activity                | Adpater used in Activity        | Adapter layout file                | Activity Layout File(s)     |
| ----------------------- | ------------------------------- | ---------------------------------- | --------------------------- |
| logDiet.CS              | CustomDefaultListAdapter.CS     | CustomSimpleListLayout.xml         | FoodDailySchedule.xml       | LogDiet.xml | foodloggedlist.Xml |
| SearchForFoodFromApi.cs | CustomSearchedAPIListAdapter.cs | DisplaySearchedAPIListLayout.xml   | SearchForFood.xml           | SearchForFoodListView.xml | NA |
| FoodLayoutSpec.cs       | FoodLayoutSpecArrayAdapter.cs   | FoodLayoutSpecListViewContents.xml | FoodLayoutSpecification.xml | NA | NA |
