import { TextField, TextFieldProps } from "@mui/material";

import {
  FieldValues,
  useController,
  UseControllerProps,
} from "react-hook-form";

type Props<T extends FieldValues> = {} & UseControllerProps<T> & TextFieldProps;

export const TextInput = <T extends FieldValues>(props: Props<T>) => {
  const { field, fieldState } = useController({ ...props });
  return (
    <TextField
      {...props}
      {...field}
      value={field.value || ""}
      fullWidth
      variant="outlined"
      error={!!fieldState.error}
      helperText={fieldState.error?.message}
    />
  );
};
