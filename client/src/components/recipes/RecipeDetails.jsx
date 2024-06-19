import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { deleteRecipe, getRecipeById, getRecipes } from '../../managers/recipeManager';
import { Button,Card, CardBody, CardTitle, CardImg, Container, Row, Col, ListGroup, ListGroupItem } from 'reactstrap';
import './RecipeDetails.css';
import ConfirmDelete from '../../modals/ConfirmDelete.jsx';

const RecipeDetails = ({loggedInUser}) => {
  const { id } = useParams();
  const [recipe, setRecipe] = useState(null);
  const [modalOpen, setModalOpen] = useState(false);
  const [deleteRecipeById, setDeleteRecipeById] = useState(null);
  const [userProfileId, setUserProfileId] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    getRecipeById(id).then(setRecipe);
  }, [id]);

  if (!recipe) {
    return <div>Loading...</div>;
  }

  const toggleModal = () => {
    setModalOpen(!modalOpen)
  };

  const handleDeleteModal = (id) => {
    setDeleteRecipeById(id);
    toggleModal();
  }

  const handleDeleteRecipe = () => {
    deleteRecipe(deleteRecipeById).then(() => {
      navigate('/recipes')

        })
  };

  const handleEdit = (recipeId) => {
    navigate(`/edit/${recipeId}`)
};

  return (
    <Container className="recipe-details-container">
      <h2 className="text-center mb-4">{recipe.name}</h2>
      <Card>
        <Row>
          <Col md="4">
            <CardImg top src={recipe.image} alt={recipe.name} />
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
            <CardBody className="d-flex justify-content-between align-items-center">
                                {loggedInUser && recipe.userProfileId === loggedInUser.id && (
                                    <Button color="danger" size="sm" onClick={() => handleDeleteModal(recipe.id)}>
                                        Delete
                                    </Button>
                                )}
                                {loggedInUser && recipe.userProfileId === loggedInUser.id && (
                                    <Button color="warning" size="sm" onClick={() => handleEdit(recipe.id)}>
                                        Edit
                                    </Button>
                                )}
                            </CardBody>
      </Card>
      <ConfirmDelete
      isOpen={modalOpen}
      toggle={toggleModal}
      confirmDelete={handleDeleteRecipe}
      typeName={"recipe"}
      />
    </Container>
  );
};

export default RecipeDetails;
