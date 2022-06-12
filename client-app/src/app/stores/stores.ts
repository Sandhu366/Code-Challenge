import { useContext } from "react";
import remarkStore from "./remarkStore";
import shoutStore from "./shoutStore";

export const useRemarkStore = () => useContext(remarkStore);
export const useShoutStore = () => useContext(shoutStore);