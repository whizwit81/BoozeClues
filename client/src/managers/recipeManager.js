const _apiUrl = "/api/CocktailRecipe";

export const getRecipes = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const getRecipeById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};


export const addRecipe = (formData) => {
    return fetch(_apiUrl, {
        method: 'POST',
        body: formData
    })
};

export const editRecipe = (id, formData) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: 'PUT',
        body: formData,
    })
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