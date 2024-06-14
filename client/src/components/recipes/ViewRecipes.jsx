import { useEffect, useState } from "react";
import { Button, Card, CardBody, CardTitle, CardImg, Container, Row, Col } from "reactstrap";
import { useNavigate } from "react-router-dom";
import "./ViewRecipes.css"; 
import { getRecipes } from "../../managers/recipeManager.js";

export const ViewCocktailRecipes = (loggedInUser) => {
    const [recipes, setRecipes] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        getRecipes().then(setRecipes);
    }, []);

    const handleDetails = (recipeId) => {
        navigate(`/recipes/${recipeId}`);
    };

    const handleEdit = (recipeId) => {
        navigate(`/editrecipe/${recipeId}`)
    };

    return (
        <Container className="cocktail-recipes-list-container">
            <h2 className="text-center">Cocktail Recipes</h2>
            <Row className="justify-content-center cocktail-recipes-list">
                {recipes.map(recipe => (
                    <Col md="4" sm="6" xs="12" key={recipe.id} className="cocktail-recipe">
                        <Card>
                            <CardBody className="d-flex justify-content-between align-items-center"> {/* <---- updated */}
                                <CardTitle tag="h3">{recipe.name}</CardTitle>
                                {loggedInUser && recipe.userProfileId === loggedInUser.id && ( // <---- added
                                    <Button color="warning" size="sm" onClick={() => handleEdit(recipe.id)}>
                                        <FaEdit />
                                    </Button>
                                )}
                            </CardBody>
                            <CardBody>
                                <Button color="info" onClick={() => handleDetails(recipe.id)}>
                                    View Recipe
                                </Button>
                            </CardBody>
                        </Card>
                    </Col>
                ))}
            </Row>
        </Container>
    );
};