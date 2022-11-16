import "./styles/datatable.scss";
import { DataGrid } from "@mui/x-data-grid";
import { Link } from "react-router-dom";
import { useState } from "react";

const Datatable = ({ rowsData, columns, viewPath, addPath, editPath, deleteFunction, hasView = true }) => {
  const [data, setData] = useState(rowsData);
  const [cols, setCols] = useState(columns);

  const handleDelete = async (id) => {
    deleteFunction(id).then((res) => {
      if (res.success) {
        setData(data.filter((item) => item.id !== id));
      }
      else
        window.location = '/servererror'

    })
  };

  const actionColumn = [
    {
      field: "action",
      headerName: "Action",
      width: 200,
      renderCell: (params) => {
        return (
          <div className="cellAction">
            {hasView ? (
              <Link to={`${viewPath}${params.row.id}`} style={{ textDecoration: "none" }}>
                <div className="viewButton">View</div>
              </Link>
            )
              : null}
            <div
              className="deleteButton"
              onClick={() => handleDelete(params.row.id)}
            >
              Delete
            </div>
            <Link to={`${editPath}${params.row.id}`} style={{ textDecoration: "none" }}>
              <div className="editButton">Edit</div>
            </Link>
          </div>
        );
      },
    },
  ];

  return (
    <div className="datatable">
      <div className="datatableTitle">

        <Link to={`${addPath}`} className="link">
          Add New
        </Link>
      </div>
      <DataGrid
        className="datagrid"
        rows={data}
        columns={cols.concat(actionColumn)}
        pageSize={9}
        rowsPerPageOptions={[9]}
        checkboxSelection
      />
    </div>
  );
};

export default Datatable;