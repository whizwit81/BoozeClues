import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getRecipeById } from '../../managers/recipeManager';
import { Card, CardBody, CardTitle, CardImg, Container, Row, Col, ListGroup, ListGroupItem } from 'reactstrap';
import './RecipeDetails.css';

const RecipeDetails = () => {
  const { id } = useParams();
  const [recipe, setRecipe] = useState(null);

  useEffect(() => {
    getRecipeById(id).then(setRecipe);
  }, [id]);

  if (!recipe) {
    return <div>Loading...</div>;
  }

  return (
    <Container className="recipe-details-container">
      <h2 className="text-center mb-4">{recipe.name}</h2>
      <Card>
        <Row>
          <Col md="4">
            <CardImg top src={recipe.imageUrl} alt={recipe.name} />
          </Col>
          <Col md="8">
            <CardBody>
              <CardTitle tag="h4">Instructions</CardTitle>
              <p>{recipe.instructions}</p>
              <CardTitle tag="h4">Ingredients</CardTitle>
              <ListGroup>
                {recipe.ingredients.map(ingredient => (
                  <ListGroupItem key={ingredient.id}>
                    {ingredient.name} ({ingredient.isAlcoholic ? 'Alcoholic' : 'Non-Alcoholic'})
                  </ListGroupItem>
                ))}
              </ListGroup>
            </CardBody>
          </Col>
        </Row>
      </Card>
    </Container>
  );
};

export default RecipeDetails;
