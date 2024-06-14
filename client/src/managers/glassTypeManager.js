const _apiUrl = "/api/GlassType";

export const getGlassTypes = () => {
    return fetch(_apiUrl).then((res) => res.json())
}
