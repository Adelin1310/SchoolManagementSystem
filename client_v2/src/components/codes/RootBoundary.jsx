import { isRouteErrorResponse, useRouteError } from "react-router-dom";
import NotFound from "./404/NotFound";
import Unauthorized from "./401/Unauthorized";

export default function RootBoundary() {
  const error = useRouteError();

  if (isRouteErrorResponse(error)) {
    if (error.data.status === 404) {
      return <NotFound/>;
    }

    if (error.data.status === 401) {
      return <Unauthorized/>;
    }

    if (error.data.status === 503) {
      return <div>Looks like our API is down</div>;
    }
  }
  console.log(error)
  return <div>Something went wrong</div>;
}
