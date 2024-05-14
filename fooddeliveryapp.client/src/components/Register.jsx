import { useState } from "react";

const Register = () => {
  const [registerResponse, setRegisterResponse] = useState("");

  const onSubmit = async (e) => {
    e.preventDefault();
    const formData = new FormData(e.currentTarget);

    const input = {
      email: formData.get("email"),
      password: formData.get("password"),
    };

    const url = "https://localhost:44341/api/AccountTest/Register";
    let response = await fetch(url, {
      headers: {
        "Content-Type": "application/json; charset=utf-8",
      },
      method: "POST",
      body: JSON.stringify(input),
    });
    let json = await response.json();
  };

  return (
    <>
      <div className="row align-items-md-center">
        <span className="text-center fs-1 fw-bold">Register</span>
        <form
          onSubmit={onSubmit}
          action="https://localhost:44341/api/AccountTest/Register"
          method="post"
        >
          <div className="col col-md-8 mx-md-auto row-gap-2 d-flex flex-column">
            <label className="form-label text-start" htmlFor="email">
              Email
            </label>
            <input
              className="form-control form-control-lg"
              id="email"
              name="email"
              type="text"
            />

            <label className="form-label text-start" htmlFor="password">
              Password
            </label>
            <input
              className="form-control form-control-lg"
              id="password"
              name="password"
              type="password"
            />

            <label className="form-label text-start" htmlFor="repassword">
              Confirm Password
            </label>
            <input
              className="form-control form-control-lg"
              id="repassword"
              name="repassword"
              type="password"
            />

            <button className="btn btn-primary" type="submit">
              submit
            </button>
          </div>
        </form>
        <div className="col text-centar">
          <span></span>
        </div>
      </div>
    </>
  );
};

export default Register;
