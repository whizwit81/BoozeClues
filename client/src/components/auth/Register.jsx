import { useState } from "react";
import { register } from "../../managers/authManager";
import { Link, useNavigate } from "react-router-dom";
import { Button, FormFeedback, FormGroup, Input, Label } from "reactstrap";

export default function Register({ setLoggedInUser }) {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  // const [imageLocation, setImageLocation] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errors, setErrors] = useState([]);
  // const[imgSrc,setImgSrc]=useState("/Images/emp.png")

  const [passwordMismatch, setPasswordMismatch] = useState();

  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      setPasswordMismatch(true);
    } else {
      const newUser = {
        firstName,
        lastName,
        userName,
        email,
        password,
        // imageLocation: imageLocation || null,
      };
      register(newUser).then((user) => {
        if (user.errors) {
          setErrors(user.errors);
        } else {
          setLoggedInUser(user);
          navigate("/");
        }
      });
    }
  };

  // const handleFileChange=(e)=>{
  //   if(e.target.files&& e.target.files[0])
  //   {
  //     let imageFile=e.target.files[0];
  //     const reader=new FileReader();
  //     reader.onload=(x)=>{
  //       setImageLocation(imageFile);
  //       setImgSrc(x.target.result)
  //     }
  //     reader.readAsDataURL(imageFile)
  //     }
  //     else{
  //       setImageLocation("");
  //     setImgSrc("/Images/emp.png")
  //     }
  //   // setImageLocation(e.target.files[0])
  // }

  return (
    <div className="container" style={{ maxWidth: "500px" }}>
      <h3>Sign Up</h3>
      <FormGroup>
        <Label>First Name</Label>
        <Input
          type="text"
          value={firstName}
          onChange={(e) => {
            setFirstName(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Last Name</Label>
        <Input
          type="text"
          value={lastName}
          onChange={(e) => {
            setLastName(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Email</Label>
        <Input
          type="email"
          value={email}
          onChange={(e) => {
            setEmail(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>User Name</Label>
        <Input
          type="text"
          value={userName}
          onChange={(e) => {
            setUserName(e.target.value);
          }}
        />
      </FormGroup>
      {/* <FormGroup>
        <Label>Upload Image</Label>           
        <img style={{height: 120, width: 100}} src={imgSrc} className="card-img-top"/>   
        <input type="file" onChange={handleFileChange} required />
      </FormGroup> */}
      <FormGroup>
        <Label>Password</Label>
        <Input
          invalid={passwordMismatch}
          type="password"
          value={password}
          onChange={(e) => {
            setPasswordMismatch(false);
            setPassword(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Confirm Password</Label>
        <Input
          invalid={passwordMismatch}
          type="password"
          value={confirmPassword}
          onChange={(e) => {
            setPasswordMismatch(false);
            setConfirmPassword(e.target.value);
          }}
        />
        <FormFeedback>Passwords do not match!</FormFeedback>
      </FormGroup>
      {errors.map((error, i) => (
        <p key={i} style={{ color: "red" }}>
          {error}
        </p>
      ))}
      <Button
        color="primary"
        onClick={handleSubmit}
        disabled={passwordMismatch}
      >
        Register
      </Button>
      <p>
        Already signed up? Log in <Link to="/login">here</Link>
      </p>
    </div>
  );
}
