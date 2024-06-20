import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
  Button,
  Card,
  CardBody,
  CardTitle,
  Form,
  FormGroup,
  Label,
  Input,
  Container,
  Row,
  Col,
} from "reactstrap";
import "./AddNewRecipe.css";
import {
  getNonAlcoholicIngredients,
  getAlcoholicIngredients,
  addRecipe,
  getRecipeById,
  editRecipe,
} from "../../managers/recipeManager";
import { getGlassTypes } from "../../managers/glassTypeManager.js";

const AddNewRecipe = ({ loggedInUser, editMode }) => {
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [instructions, setInstructions] = useState("");
  const [nonAlcoholicIngredients, setNonAlcoholicIngredients] = useState([]);
  const [alcoholicIngredients, setAlcoholicIngredients] = useState([]);
  const [selectedNonAlcoholic, setSelectedNonAlcoholic] = useState([""]);
  const [selectedAlcoholic, setSelectedAlcoholic] = useState([]);
  const [chosenIngredients, setChosenIngredients] = useState([]);
  const [glassTypes, setGlassTypes] = useState([]);
  const [chosenGlassType, setChosenGlassType] = useState("");
  const [alcoholicQuantities, setAlcoholicQuantities] = useState({});
  const [selectedFile, setSelectedFile] = useState(null);
  const navigate = useNavigate();
  const { id } = useParams();

  useEffect(() => {
    getNonAlcoholicIngredients().then(setNonAlcoholicIngredients);
    getAlcoholicIngredients().then(setAlcoholicIngredients);
    getGlassTypes().then(setGlassTypes);

    if (editMode) {
      getRecipeById(id).then((recipe) => {
        setName(recipe.name);
        setDescription(recipe.description);
        setInstructions(recipe.instructions);
        setChosenGlassType(recipe.glassTypeId);

        const nonAlcoholicIds = recipe.ingredients
          .filter((ingredient) => !ingredient.isAlcoholic)
          .map((ingredient) => ingredient.id);
        const alcoholicIds = recipe.ingredients
          .filter((ingredient) => ingredient.isAlcoholic)
          .map((ingredient) => ingredient.id);

        setSelectedNonAlcoholic(nonAlcoholicIds);
        setSelectedAlcoholic(alcoholicIds);
        setSelectedFile(recipe.image || null)
      });
    }
  }, [editMode, id]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const formData = new FormData();
    formData.append("name", name);
    formData.append("description", description);
    formData.append("instructions", instructions);
    formData.append("glassTypeId", chosenGlassType);
    formData.append("userProfileId", loggedInUser.id);

    selectedNonAlcoholic.forEach(id => formData.append("ingredients", id));
    selectedAlcoholic.forEach(id => formData.append("ingredients", id));
    if (selectedFile) {
      formData.append("image", selectedFile);
    }
    

    if (editMode) {
       await editRecipe(parseInt(id), formData);
      navigate("/recipes");
    } else {
      await addRecipe(formData);
      navigate("/recipes");
    }
  };

  const handleAddNonAlcoholic = () => {
    setSelectedNonAlcoholic([...selectedNonAlcoholic, ""]);
  };

  const handleIngredientChange = (index, value) => {
    const newNonAlcoholicIngredients = [...selectedNonAlcoholic];
    newNonAlcoholicIngredients[index] = parseInt(value);
    setSelectedNonAlcoholic(newNonAlcoholicIngredients);
  };

  const ingredientChange = (ingredientId) => {
    const selectedIngredients = [...selectedAlcoholic];
    const index = selectedIngredients.indexOf(ingredientId);

    if (index === -1) {
      selectedIngredients.push(ingredientId);
    } else {
      selectedIngredients.splice(index, 1);
    }

    setSelectedAlcoholic(selectedIngredients);
  };

  const handleCancel = () => {
    navigate("/recipes");
  };

  // const handleQuantityChange = (ingredientId, quantity) => {
  //   setAlcoholicQuantities({...alcoholicQuantities, [ingredientId]: quantity});
  // };

  const handleDeleteNonAlcoholic = (index) => {
    const newNonAlcoholicIngredients = [...selectedNonAlcoholic];
    newNonAlcoholicIngredients.splice(index, 1);
    setSelectedNonAlcoholic(newNonAlcoholicIngredients)
  }

  const fileSelectedHandler = (event) => {
    setSelectedFile(event.target.files[0]);
  };

  return (
    <Container className="add-new-recipe-container">
      {editMode ? (
        <h2 className="text-center">Edit your cocktail</h2>
      ) : (
        <h2 className="text-center">Add a New Cocktail!</h2>
      )}
      <Row>
        <Col md="6">
          <Card className="add-new-recipe-card mx-auto">
            <CardBody className="d-flex flex-column align-items-center">
              <CardTitle tag="h4" className="text-center">
                New Cocktail Recipe
              </CardTitle>
              <Form onSubmit={handleSubmit}>
                <FormGroup>
                  <Label for="name">Name</Label>
                  <Input
                    type="text"
                    name="name"
                    id="name"
                    placeholder="Enter cocktail name"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    required
                  />
                </FormGroup>
                <FormGroup>
                  <Label for="description">Description</Label>
                  <Input
                    type="text"
                    name="description"
                    id="description"
                    placeholder="Enter cocktail description"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    required
                  />
                </FormGroup>
                <FormGroup>
                  <Label for="instructions">Instructions</Label>
                  <Input
                    type="textarea"
                    name="instructions"
                    id="instructions"
                    placeholder="Enter cocktail instructions"
                    value={instructions}
                    onChange={(e) => setInstructions(e.target.value)}
                    required
                  />
                </FormGroup>
                <FormGroup>
                  <Label for="glassType">Glass Type</Label>
                  <Input
                    type="select"
                    name="glassType"
                    id="glassType"
                    value={chosenGlassType}
                    onChange={(e) => setChosenGlassType(e.target.value)}
                    required
                  >
                    <option value="">Select a glass type</option>
                    {glassTypes.map((glassType) => (
                      <option key={glassType.id} value={glassType.id}>
                        {glassType.name}
                      </option>
                    ))}
                  </Input>
                </FormGroup>
                <FormGroup>
                <Label for="nonAlcoholic">Non-Alcoholic Ingredients</Label>
                  {selectedNonAlcoholic.map((ingredient, index) => (
                    <div key={index} className="d-flex align-items-center">
                      <Input
                        type="select"
                        name={`nonAlcoholic-${index}`}
                        id={`nonAlcoholic-${index}`}
                        value={ingredient}
                        onChange={(e) =>
                          handleIngredientChange(index, e.target.value)
                        }
                      >
                        <option value="">Select an ingredient</option>
                        {nonAlcoholicIngredients.map((ingredient) => (
                          <option key={ingredient.id} value={ingredient.id}>
                            {ingredient.name}
                          </option>
                        ))}
                      </Input>
                      {editMode && (
                        <Button
                          type="button"
                          color="danger"
                          size="sm"
                          onClick={() => handleDeleteNonAlcoholic(index)}
                          className="ml-2"
                        >
                          &times;
                        </Button>
                      )}
                    </div>
                  ))}
                  <Button type="button" onClick={handleAddNonAlcoholic}>
                    Add Another Non-Alcoholic Ingredient
                  </Button>
                </FormGroup>
              </Form>
            </CardBody>
          </Card>
        </Col>
        <Col md="6">
          <Card className="add-new-recipe-card mx-auto mt-4">
            <CardBody>
              <CardTitle tag="h4" className="text-center">
                Alcoholic Ingredients
              </CardTitle>
              <FormGroup>
                {alcoholicIngredients.map((ingredient) => (
                  <FormGroup check inline key={ingredient.id}>
                    <Label check>
                      <Input
                        type="checkbox"
                        value={ingredient.id}
                        checked={selectedAlcoholic.includes(ingredient.id)}
                        onChange={() => {
                          ingredientChange(ingredient.id);
                        }}
                      />
                      {""}
                      {ingredient.name}
                    </Label>
                  </FormGroup>
                ))}
              </FormGroup>
              <FormGroup>
                <Input
                type="file"
                onChange={fileSelectedHandler} 
                >
                </Input>
              </FormGroup>
            </CardBody>
          </Card>
        </Col>
      </Row>
      <Row className="mt-4">
        <Col className="d-flex justify-content center">
          <Button
            type="submit"
            color="primary"
            block
            className="mx-2"
            onClick={handleSubmit}
          >
            {editMode ? "Submit Edit" : "Add Cocktail"}
          </Button>
          <Button
            type="button"
            color="danger"
            className="mx-2"
            onClick={handleCancel}
          >
            Cancel
          </Button>
        </Col>
      </Row>
    </Container>
  );
};

export default AddNewRecipe;
