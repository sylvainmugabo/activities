import { MapContainer, Marker, Popup, TileLayer } from "react-leaflet";
import "leaflet/dist/leaflet.css";
import { LatLng } from "leaflet";

type Props = {
  longitude: number;
  latitude: number;
  venue: string;
};
export const MapComponent = ({ longitude, latitude, venue }: Props) => {
  return (
    <MapContainer
      center={new LatLng(latitude, longitude)}
      zoom={13}
      scrollWheelZoom={false}
      style={{ height: "100%" }}
    >
      <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
      <Marker position={[latitude, longitude]}>
        <Popup>{venue}</Popup>
      </Marker>
    </MapContainer>
  );
};
