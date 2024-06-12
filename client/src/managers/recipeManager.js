const _apiUrl = "/api/CocktailRecipe";

export const getRecipes = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const getRecipeById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};
