import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { Home } from "../Home.jsx";
import { ViewCocktailRecipes } from "./recipes/ViewRecipes.jsx";
import RecipeDetails from "./recipes/RecipeDetails.jsx";
import AddNewRecipe from "./recipes/AddNewRecipe.jsx";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Home loggedInUser={loggedInUser}/>
            </AuthorizedRoute>
          }
          />
          <Route
            path="login"
            element={<Login setLoggedInUser={setLoggedInUser} />}
          />
          <Route
            path="register"
            element={<Register setLoggedInUser={setLoggedInUser} />}
          />
      </Route>
      <Route path="/recipes"><Route index element={<AuthorizedRoute loggedInUser={loggedInUser}><ViewCocktailRecipes loggedInUser={loggedInUser} /></AuthorizedRoute>}/>
      <Route path=":id"element={<AuthorizedRoute loggedInUser={loggedInUser}><RecipeDetails loggedInUser={loggedInUser} /></AuthorizedRoute>
        }
      />
        </Route>
        <Route
        path="/add"
        element={
          <AuthorizedRoute loggedInUser={loggedInUser}>
            <AddNewRecipe loggedInUser={loggedInUser} />
          </AuthorizedRoute>
        }
      />
      <Route path="/edit"><Route index element={<AuthorizedRoute loggedInUser={loggedInUser}><RecipeDetails loggedInUser={loggedInUser} /></AuthorizedRoute>}/>
      <Route path=":id"element={<AuthorizedRoute loggedInUser={loggedInUser}><AddNewRecipe editMode={true} loggedInUser={loggedInUser} /></AuthorizedRoute>
        }
      />
      </Route>
    </Routes>
  );
}