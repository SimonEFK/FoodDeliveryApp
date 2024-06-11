import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";

const loginSchema = z.object({
  email: z.string().email(),
  password: z.string().min(10),
});

const LoginForm = () => {
  const onSubmit = async (data) => {
    const url = "https://localhost:44341/api/UserAuthentication/Login";
    const options = {
      headers: {
        "content-type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(data),
    };
    const response = await fetch(url, options);
    const json = await response.json();
    console.log(json);
  };

  const {
    register,
    handleSubmit,
    formState: { errors, isSubmitting },
    setError,
    reset,
  } = useForm({
    resolver: zodResolver(loginSchema),
  });

  return (
    <>
      <div className="row justify-content-center">
        <div className="col-4 ">
          <span className="fs-1 text-center">Login</span>
          <form
            action="https://localhost:44341/api/UserAuthentication/Login"
            onSubmit={handleSubmit(onSubmit)}
          >
            <div>
              <label className="form-label" htmlFor="email">
                Email
              </label>
              <input
                id="email"
                type="text"
                className="form-control form-control-lg"
                {...register("email")}
              />
              {errors.email && (
                <span className="text-danger">{errors.email.message}</span>
              )}
            </div>

            <div>
              <label className="form-label" htmlFor="password">
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

            <button className="btn btn-primary mt-3">Submit</button>
          </form>
        </div>
      </div>
    </>
  );
};
export default LoginForm;
