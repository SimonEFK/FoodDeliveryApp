import { zodResolver } from "@hookform/resolvers/zod";
import { set, useForm } from "react-hook-form";
import { z } from "zod";

const registerSchema = z
  .object({
    email: z.string().email(),
    password: z.string().min(10),
    confirmPassword: z.string(),
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: "Passwords didn't match",
    path: ["confirmPassword"],
  });

const Register = () => {
  const onSubmit = async (data) => {
    let url = "https://localhost:44341/api/UserAuthentication/Register";
    let options = {
      method: "POST",
      headers: {
        "content-type": "application/Json",
      },
      body: JSON.stringify(data),
    };

    const response = await fetch(url, options);

    if (response.ok) {
      console.log(response);
    } else if (!response.ok) {
      const json = await response.json();
      if (json.errors) {
        const errors = json.errors;
        console.log(errors);
      }
    }

    reset();
  };

  const {
    register,
    handleSubmit,
    formState: { errors, isSubmitting },
    setError,
    reset,
  } = useForm({
    resolver: zodResolver(registerSchema),
  });

  return (
    <>
      <div className="container">
        <div className="row">
          <div className="col-4">
            <span className="fs-1">Register</span>
            <form
              action="https://localhost:44341/api/UserAuthentication/Register"
              onSubmit={handleSubmit(onSubmit)}
            >
              <div>
                <label htmlFor="email" className="form-label">
                  Email
                </label>
                <input
                  id="email"
                  className="form-control form-control-lg"
                  {...register("email")}
                />
                {errors.email && (
                  <span className="text-danger">{errors.email.message}</span>
                )}
              </div>

              <div>
                <label htmlFor="password" className="form-label">
                  Password
                </label>
                <input
                  id="password"
                  type="password"
                  className="form-control form-control-lg"
                  {...register("password")}
                />
                {errors.password && (
                  <span className="text-danger">{errors.password.message}</span>
                )}
              </div>
              <div>
                <label htmlFor="confirmPassword" className="form-label">
                  Confirm Password
                </label>
                <input
                  id="confirmPassword"
                  type="password"
                  className="form-control form-control-lg"
                  {...register("confirmPassword")}
                />
                {errors.confirmPassword && (
                  <span className="text-danger">
                    {errors.confirmPassword.message}
                  </span>
                )}
              </div>
              <button disabled={isSubmitting} className="btn btn-primary mt-3">
                {isSubmitting ? "Loading" : "Submit"}
              </button>
            </form>
          </div>
        </div>
      </div>
    </>
  );
};
export default Register;
