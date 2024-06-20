import { useEffect, useState } from "react";
import { Button, Card, CardBody, CardTitle, CardImg, Container, Row, Col } from "reactstrap";
import { useNavigate } from "react-router-dom";
import "./ViewRecipes.css"; 
import { getRecipes } from "../../managers/recipeManager.js";

export const ViewCocktailRecipes = ({loggedInUser}) => {
    const [recipes, setRecipes] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        getRecipes().then(setRecipes);

    }, []);

    const handleDetails = (recipeId) => {
        navigate(`/recipes/${recipeId}`);
    };


    return (
        <Container className="cocktail-recipes-list-container">
            <h2 className="text-center">Cocktail Recipes</h2>
            <Row className="justify-content-center align-items-center cocktail-recipes-list">
                {recipes.map(recipe => (
                    <Col md="4" sm="6" xs="12" key={recipe.id} className="cocktail-recipe">
                        <Card className="h-100" d-flex flex-row align-items-center> 
                            <CardImg 
                                src={recipe.image} 
                                alt={recipe.name} 
                                className="recipe-image" 
                            />
                            <CardBody className="d-flex flex-column justify-content-between align-items-center">
                                <CardTitle tag="h3" className="text-center">{recipe.name}</CardTitle>
                                <Button className="custom-button" onClick={() => handleDetails(recipe.id)}>
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