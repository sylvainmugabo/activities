type Activity = {
  id?: string;
  title: string;
  date: Date;
  description: string;
  category: string;
  isCancelled?: boolean;
  city?: string;
  venue: string;
  latitude: number;
  longitude: number;
};

type User = {
  id: string;
  email: string;
  displayName: string;
  imageUrl?: string;
};

type LocationIqSuggestion = {
  place_id: string;
  osm_id: string;
  osm_type: string;
  licence: string;
  lat: string;
  lon: string;
  boundingbox: string[];
  class: string;
  type: string;
  display_name: string;
  display_place: string;
  display_address: string;
  address: LocationIqAddress;
};

type LocationIqAddress = {
  name: string;
  road: string;
  suburb: string;
  city?: string;
  town?: string;
  village?: string;
  county: string;
  state: string;
  country: string;
  country_code: string;
};
