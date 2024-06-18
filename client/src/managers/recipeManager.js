const _apiUrl = "/api/CocktailRecipe";

export const getRecipes = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const getRecipeById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};


export const addRecipe = (newRecipe) => {
    return fetch(_apiUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newRecipe)
    })
};

export const editRecipe = (id, updatedRecipe) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(updatedRecipe)
    });
};

export const getNonAlcoholicIngredients = () => {
    return fetch(`${_apiUrl}/non-alcoholic`)
        .then(response => {
            if (response.ok) {
                return response.json();
            }
            throw new Error('Failed to fetch non-alcoholic ingredients');
        });
};

export const getAlcoholicIngredients = () => {
    return fetch(`${_apiUrl}/alcoholic`)
        .then(response => {
            if (response.ok) {
                return response.json();
            }
            throw new Error('Failed to fetch alcoholic ingredients');
        });
};

export const deleteRecipe = (id) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: "DELETE",
        headers: {
            "Content-Type" : "application/json",
        }
    });
};