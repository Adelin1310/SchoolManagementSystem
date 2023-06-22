import { isRouteErrorResponse, useRouteError } from "react-router-dom";
import NotFound from "./404/NotFound";
import Unauthorized from "./401/Unauthorized";
import InternalServer from "./500/InternalServer";

export default function RootBoundary() {
  const error = useRouteError();

  if (isRouteErrorResponse(error)) {
    console.log(error)
    if (error.data.status === 500) return <InternalServer/>;

    if (error.status === 404) {
      return <NotFound />;
    }

    if (error.status === 401 || error.data.status) {
      return <Unauthorized />;
    }
  }
  return <div>Error: {error.toString()}</div>;
}
