import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { LoginSchema } from "../util/schemas/loginSchema";
import agent from "../api/agent";
import { useLocation, useNavigate } from "react-router";

export const useAccount = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const queryClient = useQueryClient();
  const loginUser = useMutation({
    mutationFn: async (creds: LoginSchema) => {
      await agent.post("/login?useCookies=true", creds);
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({
        queryKey: ["user"],
      });
    },
  });

  const { data: currentUser } = useQuery({
    queryKey: ["user"],
    queryFn: async () => {
      const response = await agent.get<User>("/account/user-info");
      return response.data;
    },
    enabled:
      !queryClient.getQueryData(["user"]) &&
      location.pathname !== "/login" &&
      location.pathname !== "/register",
  });
  return {
    loginUser,
    currentUser,
  };
};
