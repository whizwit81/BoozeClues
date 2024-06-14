import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import {Button,Card,CardBody,CardTitle,Form,FormGroup,Label,Input,Container,Row,Col,} from "reactstrap";
import "./AddNewRecipe.css";
import {getNonAlcoholicIngredients,getAlcoholicIngredients,addRecipe,} from "../../managers/recipeManager";
import { getGlassTypes } from "../../managers/glassTypeManager.js";

const AddNewRecipe = ({ loggedInUser }) => {
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [instructions, setInstructions] = useState("");
  const [nonAlcoholicIngredients, setNonAlcoholicIngredients] = useState([]);
  const [alcoholicIngredients, setAlcoholicIngredients] = useState([]);
  const [selectedNonAlcoholic, setSelectedNonAlcoholic] = useState(['']);
  const [selectedAlcoholic, setSelectedAlcoholic] = useState([]);
  const [chosenIngredients, setChosenIngredients] = useState([]);
  const [glassTypes, setGlassTypes] = useState([]);
  const [chosenGlassType, setChosenGlassType] = useState("");
  const [alcoholicQuantities, setAlcoholicQuantities] = useState({});
  const navigate = useNavigate();

  useEffect(() => {
    getNonAlcoholicIngredients().then(setNonAlcoholicIngredients);
    getAlcoholicIngredients().then(setAlcoholicIngredients);
    getGlassTypes().then(setGlassTypes);
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const newRecipe = {
      name: name,
      description: description,
      instructions: instructions,
      ingredients: [
        ...selectedNonAlcoholic.map(id => ({id, quantity: '1 oz'})), //may need to remove - check and see how this looks.
        ...selectedAlcoholic.map(id => ({id, quantity: alcoholicQuantities[id] || '1 oz'})) //may need to remove - check and see how this looks.
      ],
      userProfileId: loggedInUser.id,
      glassTypeId: chosenGlassType,
    };

    await addRecipe(newRecipe);
    navigate("/recipes");
  };

//   const handleAddIngredient = () => {
//     setAdditionalIngredients([
//       ...additionalIngredients,
//       { id: "", quantity: "1 oz" },
//     ]);
//   };

  const handleAddNonAlcoholic = () => {
        setSelectedNonAlcoholic([...selectedNonAlcoholic, '']);
  };

  const handleIngredientChange = (index, value) => {
    const newNonAlcoholicIngredients = [...selectedNonAlcoholic];
    newNonAlcoholicIngredients[index] = parseInt(value);
    setSelectedNonAlcoholic(newNonAlcoholicIngredients);
  }

  const ingredientChange = (ingredientId) => {
      const selectedIngredients = [...selectedAlcoholic];
      const index = selectedIngredients.indexOf(ingredientId)

      if(index === -1)
          {
              selectedIngredients.push(ingredientId)
          }
      else
      {
          selectedIngredients.splice(index, 1)
      }

      setSelectedAlcoholic(selectedIngredients);
  }

  const handleQuantityChange = (ingredientId, quantity) => {
    setAlcoholicQuantities({...alcoholicQuantities, [ingredientId]: quantity});
  };

  return (
    <Container className="add-new-recipe-container">
      <h2 className="text-center">Add a New Cocktail!</h2>
      <Card className="add-new-recipe-card mx-auto">
        <CardBody>
          <CardTitle tag="h4" className="text-center">New Cocktail Recipe</CardTitle>
          <Form onSubmit={handleSubmit}>
            <Row>
              <Col md="6">
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
                    <Input
                      type="select"
                      name={`nonAlcoholic-${index}`}
                      id={`nonAlcoholic-${index}`}
                      value={ingredient}
                      onChange={(e) =>
                        handleIngredientChange(index, e.target.value)
                      }
                      key={index}
                    >
                      <option value="">Select an ingredient</option>
                      {nonAlcoholicIngredients.map(ingredient => (
                        <option key={ingredient.id} value={ingredient.id}>
                          {ingredient.name}
                        </option>
                      ))}
                    </Input>
                  ))}
                  <Button type="button" onClick={handleAddNonAlcoholic}>
                    Add Another Non-Alcoholic Ingredient
                  </Button>
                </FormGroup>
                </Col>
            </Row>
            <Button type="submit" color="primary" block>Add Cocktail</Button>
          </Form>
        </CardBody>
      </Card>
      <Card className="add-new-recipe-card mx-auto mt-4">
        <CardBody>
            <CardTitle tag="h4" className="text-center">Alcoholic Ingredients</CardTitle>
            <FormGroup>
                {alcoholicIngredients.map((ingredient) => (
                    <Row key={ingredient.id} className="align-items-center mb-2">
                        <Col md="8">
                        <Label check>
                            <Input
                            type="checkbox"
                            value={ingredient.id}
                            onChange={() => {ingredientChange(ingredient.id)}}
                            /> {''}
                            {ingredient.name}
                        </Label>
                        </Col>
                        <Col md="4">
                        <Input
                        type="text"
                        placeholder="Quantity (oz)"
                        value={alcoholicQuantities[ingredient.id] || ''}
                        onChange={(e) => handleQuantityChange(ingredient.id, e.target.value)}
                        disabled={!selectedAlcoholic.includes(ingredient.id)}
                        />
                        </Col>
                    </Row>
                ))}
            </FormGroup>
        </CardBody>
      </Card>
    </Container>
  );
};

export default AddNewRecipe;
